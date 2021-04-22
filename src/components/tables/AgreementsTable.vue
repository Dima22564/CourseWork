<template>
  <div>
    <q-table
      :data="data"
      :columns="columns"
      row-key="name"
      binary-state-sort
      :loading="loading"
      no-data-label="Нет данных"
    >
      <template v-slot:top>
        <div class="flex justify-between flex-center" style="width: 100%">
          <h6 class="q-ma-none">Соглашения</h6>
          <q-btn
            v-if="$route.params.partnerId"
            :to="'/new-agreement/create?partner=' + $route.params.partnerId"
            size="sm"
            color="primary"
            :icon="icons.mdiPencil"
            label="создать новое соглашение"
          >
            <q-tooltip>
              Создать новое соглашение для данного партнера
            </q-tooltip>
          </q-btn>
          <q-btn
            v-else
            :to="'/new-agreement/create'"
            size="sm"
            color="primary"
            :icon="icons.mdiPencil"
            label="создать новое соглашение"
          />
        </div>
      </template>
      <template v-slot:body="props">
        <q-tr :props="props">
          <q-td key="agreementId" :props="props">
            {{ props.row.agreementId }}
          </q-td>

          <q-td key="name" :props="props">
            {{ props.row.name }}
          </q-td>

          <q-td key="vatRate" :props="props">
            {{ props.row.vatRate }}
          </q-td>

          <q-td key="validFrom" :props="props">
            {{ props.row.validFrom }}
          </q-td>

          <q-td key="validTo" :props="props">
            {{ props.row.validTo }}
          </q-td>

          <q-td key="currency" :props="props">
            {{ props.row.currency }}
          </q-td>

          <q-td key="status" :props="props">
            {{ props.row.status }}
          </q-td>

          <q-td key="actions" :props="props">
            <q-btn-dropdown class="q-mr-sm" size="sm" color="deep-orange" label="Изменить статус">
              <q-list>
                <q-item clickable v-close-popup @click="approve(props.row.agreementId)">
                  <q-item-section>
                    <q-item-label>Утвердить</q-item-label>
                  </q-item-section>
                </q-item>

                <q-item clickable v-close-popup @click="deny(props.row.agreementId)">
                  <q-item-section>
                    <q-item-label>Отклонить</q-item-label>
                  </q-item-section>
                </q-item>

                <q-item clickable v-close-popup @click="cancel(props.row.agreementId)">
                  <q-item-section>
                    <q-item-label>Аннулировать</q-item-label>
                  </q-item-section>
                </q-item>
              </q-list>
            </q-btn-dropdown>
            <q-btn
              :to="'/new-agreement/create?oldAgreement=' + props.row.agreementId"
              color="primary"
              class="q-mr-sm"
              size="sm"
              label="Создать"
              :loading="loading"
            >
              <q-tooltip>
                Создать новое соглашение на основании данного
              </q-tooltip>
            </q-btn>
            <q-btn :to="'/agreement/' + props.row.agreementId" class="q-mr-sm" color="secondary" size="sm" :icon="icons.mdiMagnify" :loading="loading" />
            <q-btn class="q-mr-sm" color="info" size="sm" :icon="icons.mdiAccountSearch" :loading="loading">
              <q-tooltip>Просмотр ответственного лица.</q-tooltip>
            </q-btn>
            <q-btn
              :to="'/agreement/' + props.row.agreementId"
              color="purple"
              size="sm"
              :icon="icons.mdiSend"
              :loading="loading"
            >
              <q-tooltip>
                Отправить соглашение на утверждение партнеру.
              </q-tooltip>
            </q-btn>
          </q-td>
        </q-tr>
      </template>
    </q-table>

  </div>
</template>

<script>
import icons from 'src/mixins/icons'

export default {
  name: 'AgreementsTable',
  mixins: [icons],
  props: {
    data: {
      type: Array,
      default: () => []
    }
  },
  methods: {
    saveChanges (partnerId) {
    },
    approve (agreementId) {
    },
    deny (agreementId) {
    },
    cancel (agreementId) {
    }
  },
  data: () => {
    return {
      loading: false,
      createAgreement: false,
      columns: [
        { name: 'agreementId', label: '#', align: 'left', field: 'agreementId' },
        { name: 'name', label: 'Название', field: 'name' },
        { name: 'vatRate', label: 'Ставка НДС', field: 'vatRate' },
        { name: 'validFrom', label: 'Действует с', field: 'validFrom' },
        { name: 'validTo', label: 'Действует по', field: 'validTo' },
        { name: 'currency', label: 'Валюта', field: 'currency' },
        { name: 'status', label: 'Статус', field: 'status' },
        { name: 'actions', label: 'Действия', field: 'actions' }
      ]
    }
  }
}
</script>
