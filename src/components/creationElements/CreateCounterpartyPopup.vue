<template>
  <div class="q-pa-lg" style="min-width: 500px">

    <q-form
      @submit="onSubmit"
      @reset="onReset"
      class="q-gutter-md"
      ref="form"
    >
      <q-input
        filled
        v-model="tin"
        label="ИНН"
        hint="ИНН"
        dense
        lazy-rules
        :rules="[ val => val && val.length > 0 || 'Поле обязательно для заполнения']"
      />

      <q-input
        filled
        v-model="crtr"
        label="CRTR"
        hint="CRTR"
        dense
        lazy-rules
        :rules="[ val => val && val.length > 0 || 'Поле обязательно для заполнения']"
      />

      <q-input
        filled
        v-model="workName"
        label="Сокращенное название"
        hint="Сокращенное название"
        dense
        lazy-rules
        :rules="[ val => val && val.length > 0 || 'Поле обязательно для заполнения']"
      />

      <q-input
        filled
        v-model="fullName"
        label="Полное название"
        hint="Полное название"
        dense
        lazy-rules
        :rules="[ val => val && val.length > 0 || 'Поле обязательно для заполнения']"
      />

      <div>
        <q-btn :loading="loading" label="Создать" type="submit" color="primary"/>
        <q-btn :loading="loading" label="Сбросить" type="reset" color="primary" flat class="q-ml-sm" />
      </div>
    </q-form>

  </div>
</template>

<script>
export default {
  data: () => {
    return {
      workName: null,
      fullName: null,
      crtr: null,
      tin: null,
      loading: false
    }
  },
  methods: {
    async onSubmit () {
      this.loading = true

      const form = new FormData()
      form.append('WorkName', this.workName)
      form.append('FullName', this.fullName)
      form.append('Crtr', this.crtr)
      form.append('Tin', this.tin)
      try {
        const result = await this.$store.dispatch('counterparty/create', form)
        if (result.status === 201) {
          this.$q.notify({
            type: 'positive',
            message: 'Контрагент добавлен успешно'
          })
        }
        this.onReset()
      } catch (e) {
        this.$q.notify({
          type: 'negative',
          message: e.response.data.message
        })
      } finally {
        this.loading = false
      }
    },
    onReset () {
      this.workName = null
      this.fullName = null
      this.crtr = null
      this.tin = null

      this.$refs.form.resetValidation()
    }
  }
}
</script>
